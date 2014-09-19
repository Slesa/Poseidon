#I @"tools\Fake"
#r "FakeLib.dll"

open Fake
open System.IO
open Fake.AssemblyInfoFile

// properties
let projectName = "Poseidon"
let projectSummary = "Poseidon - a POS environment"
let authors = ["J. Preiss"]
let mail = "joerg.preiss@slesa.de"
let homepage = "http://github.com/Slesa/Poseidon"

TraceEnvironmentVariables()

// Directories
let binDir = @".\bin\"
let buildDir = binDir @@ @"build\"
let testDir = binDir @@ @"test\"
let metricsDir = binDir @@ @"metrics\"
let reportDir = binDir @@ @"report\"
let deployDir = binDir @@ @"deploy\"
let packagesDir = binDir @@ @"packages"
let mspecDir = packagesDir @@ "MSpec"

// tools

// files
let appReferences = 
  !! @"src\BackOffice\BackOffice.sln"
    
let testReferences = !! @"src\BackOffice\**\*.Specs.*sproj"
let deployReferences =
  !! @"Setup\Setup.sln"
   
let setupDir = @"Setup\"

// Targets

Target "Clean" (fun _ ->
  CleanDirs [buildDir; testDir; deployDir; metricsDir; reportDir; packagesDir]

)


let currentVersion =
  if not isLocalBuild then buildVersion else
  "0.0.0.1"


Target "SetAssemblyInfo" (fun _ ->

    [Attribute.Product projectName
     Attribute.Version currentVersion
     Attribute.Company "Slesa Solutions"
     Attribute.Copyright "Copyright ©  2012"
     Attribute.Trademark "GPL V2"]
     |> CreateCSharpAssemblyInfo "./src/VersionInfo.cs"

)

Target "BuildApp" (fun _ ->
  MSBuildRelease buildDir "Build" appReferences
    |> Log "AppBuild-Output: "
)

Target "BuildTest" (fun _ ->
  MSBuildDebug testDir "Build" testReferences
    |> Log "TestBuildOutput: "
)

Target "Deploy" (fun _ ->

  let outputName = sprintf "%s-Setup.%s.msi" projectName currentVersion
  let defines = "Version="+currentVersion

  MSBuildReleaseExt deployDir ["ProductVersion", currentVersion; "DefineConstants", defines; "OutputName", outputName] "Build" deployReferences
    |> Log "DeployBuildOutput: "
)

Target "Test" (fun _ ->

  let mspecTool = findToolInSubPath "mspec-x86-clr4.exe" @".\src\BackOffice\packages"
  trace mspecTool

  !! (testDir @@ "*.Specs.dll")
    |> MSpec (fun p ->
      {p with
        ToolPath = mspecTool
        HtmlOutputDir = reportDir})
)

Target "Default" DoNothing

// Dependencies
"Clean"
  ==> "SetAssemblyInfo"
  ==> "BuildApp" <=> "BuildTest"
//  ==> "Test"
  ==> "Deploy"
  ==> "Default"

if not isLocalBuild then
  "Clean" ==> "SetAssemblyInfo" ==> "BuildApp" |> ignore

// start build
RunParameterTargetOrDefault "target" "Default"

