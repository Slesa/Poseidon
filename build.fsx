// --------------------------------------------------------------------------------------
// FAKE build script
// --------------------------------------------------------------------------------------

#r @"packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.AssemblyInfoFile
open Fake.ReleaseNotesHelper
open System
open System.IO
#if MONO
#else
#load "packages/SourceLink.Fake/Tools/Fake.fsx"
open SourceLink
#endif

// --------------------------------------------------------------------------------------
// Variables
// --------------------------------------------------------------------------------------

// Information about the project are used
//  - for version and project name in generated AssemblyInfo file
//  - by the generated NuGet package
//  - to run tests and to publish documentation on GitHub gh-pages
//  - for documentation, you also need to edit info in "docs/tools/generate.fsx"

// The name of the project
// (used by attributes in AssemblyInfo, name of a NuGet package and directory in 'src')
let project = "Poseidon"

// Short summary of the project
// (used as description in AssemblyInfo and as a short summary for NuGet package)
let summary = "A POS environment"

// Longer description of the project
// (used as a description for NuGet package; line breaks are automatically cleaned up)
let description = "A Backoffice, some Frontoffices, and probably a few tools shall build a complete working Point Of Sale environment"

// List of author names (for NuGet package)
let authors = [ "J. Preiss" ]
let mail = "joerg.preiss@slesa.de"

// Git configuration (used for publishing documentation in gh-pages branch)
// The profile where the project is posted
let gitOwner = "Slesa" 
let gitHome = "https://github.com/" + gitOwner

// The name of the project on GitHub
let gitName = "Poseidon"

// The url for the raw files hosted
let gitRaw = environVarOrDefault "gitRaw" "https://raw.github.com/Slesa"

// --------------------------------------------------------------------------------------
// Directories
// --------------------------------------------------------------------------------------

// The subfolder for all files to create via build
let binDir = @".\bin\"

// Path where release builds will be compiled to
let buildDir = binDir @@ @"build\"

// Path where test builds will be compiled to
let testDir = binDir @@ @"test\"

// Path where test reports will be stored to
let reportDir = binDir @@ @"report\"

// Path where deployment packages will be created
let deployDir = binDir @@ @"deploy\"

// --------------------------------------------------------------------------------------
// Current Version
// --------------------------------------------------------------------------------------

let currentVersion =
  if not isLocalBuild then buildVersion else
  "0.0.0.1"

// --------------------------------------------------------------------------------------
// End 
// --------------------------------------------------------------------------------------


// Read additional information from the release notes document
let release = LoadReleaseNotes "RELEASE_NOTES.md"

let genFSAssemblyInfo (projectPath) =
    let projectName = System.IO.Path.GetFileNameWithoutExtension(projectPath)
    let folderName = System.IO.Path.GetDirectoryName(projectPath)
    let basePath = "src/" + folderName
    let fileName = basePath + "/AssemblyInfo.fs"
    CreateFSharpAssemblyInfo fileName
      [ Attribute.Title (projectName)
        Attribute.Product project
        Attribute.Description summary
        Attribute.Version release.AssemblyVersion
        Attribute.FileVersion release.AssemblyVersion ]

let genCSAssemblyInfo (projectPath) =
    let projectName = System.IO.Path.GetFileNameWithoutExtension(projectPath)
    let folderName = System.IO.Path.GetDirectoryName(projectPath)
    let basePath = folderName + "/Properties"
    let fileName = basePath + "/AssemblyInfo.cs"
    CreateCSharpAssemblyInfo fileName
      [ Attribute.Title (projectName)
        Attribute.Product project
        Attribute.Description summary
        Attribute.Version release.AssemblyVersion
        Attribute.FileVersion release.AssemblyVersion ]

// Generate assembly info files with the right version & up-to-date information
Target "AssemblyInfo" (fun _ ->
  let fsProjs =  !! "src/**/*.fsproj"
  let csProjs = !! "src/**/*.csproj"
  fsProjs |> Seq.iter genFSAssemblyInfo
  csProjs |> Seq.iter genCSAssemblyInfo
)

Target "SetAssemblyInfo" (fun _ ->

    [Attribute.Product project
     Attribute.Version currentVersion
     Attribute.Company "Slesa Solutions"
     Attribute.Copyright "Copyright ©  2012"
     Attribute.Trademark "GPL V2"]
     |> CreateCSharpAssemblyInfo "./src/VersionInfo.cs"
)

// --------------------------------------------------------------------------------------
// Clean build results

Target "Clean" (fun _ ->
  CleanDirs [buildDir; testDir; deployDir; reportDir]
)


// --------------------------------------------------------------------------------------
// Build library & test project

Target "Build" (fun _ ->

  let appReferences = !! @"src\BackOffice.sln"

  MSBuildRelease buildDir "Build" appReferences
    |> Log "AppBuild-Output: "
)


// --------------------------------------------------------------------------------------
// Run the unit tests using test runner

Target "BuildTests" (fun _ ->

  let testReferences = !! @"src\BackOffice\**\*.Specs.*sproj"

  MSBuildDebug testDir "Build" testReferences
   |> Log "TestBuildOutput: "
)


Target "RunTests" (fun _ ->

  let mspecTool = findToolInSubPath "mspec-x86-clr4.exe" @".\src\packages"
  trace mspecTool

  !! (testDir @@ "*.Specs.dll")
    |> MSpec (fun p ->
      {p with
        ToolPath = mspecTool
        HtmlOutputDir = reportDir})
)


// --------------------------------------------------------------------------------------
// Release Scripts

Target "Deploy" (fun _ ->

  let deployReferences = !! @"Setup\Setup.sln"
  let outputName = sprintf "%s-Setup.%s.msi" project currentVersion
  let defines = "Version="+currentVersion

  MSBuildReleaseExt deployDir ["ProductVersion", currentVersion; "DefineConstants", defines; "OutputName", outputName] "Build" deployReferences
    |> Log "DeployBuildOutput: "
)


// --------------------------------------------------------------------------------------
// Run all targets by default. Invoke 'build <Target>' to override

Target "All" DoNothing

"Clean"
  =?> ("SetAssemblyInfo",not isLocalBuild)
  ==> "Build" <=> "BuildTests"
  ==> "RunTests"
  ==> "Deploy"
//  =?> ("GenerateReferenceDocs",isLocalBuild && not isMono)
  ==> "All"

RunTargetOrDefault "All"
