#I @"tools\Fake"
#r "FakeLib.dll"

open Fake

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
let appReferences = !! @"src\**\*.*sproj"
//  -- "**\*.Specs.*sproj"
let testReferences = !! @"src\**\*.Specs.*sproj"
let deployReferences = !! @"Setup\**\*.wixproj"
let setupDir = @"Setup\"

// Targets

Target "Clean" (fun _ ->
  CleanDirs [buildDir; testDir; deployDir; metricsDir; reportDir; packagesDir]

  CreateDir mspecDir
  !! (@"src\Domain\packages\Machine.Specifications.*\**\*.*")
    |> CopyTo mspecDir
)

let currentVersion =
  if not isLocalBuild then buildVersion else
  "0.0.0.1"

Target "SetAssemblyInfo" (fun _ ->
  AssemblyInfo
    (fun p ->
    {p with
      CodeLanguage = CSharp;
      Guid = "";
      ComVisible = None;
      CLSCompliant = None;
      AssemblyCompany = "Slesa Solutions";
      AssemblyProduct = "Poseidon";
      AssemblyCopyright = "Copyright ©  2012";
      AssemblyTrademark = "GPL V2";
      AssemblyVersion = currentVersion;
      OutputFileName = @".\src\VersionInfo.cs"})
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
//  let deployMsi = deployDir @@ sprintf "%s-%s.msi" projectName currentVersion
//  !! (setupDir @@ "*.wxl")
//    |> WiX (fun p -> WiXDefaults) deployMsi 
  MSBuildReleaseExt deployDir ["Version", currentVersion] "Build" deployReferences
    |> Log "DeployBuildOutput: "
)

Target "Test" (fun _ ->
//  let MSpecVersion = GetPackageVersion packagesDir "Machine.Specifications"
//  trace MSpecVersion
  let mspecTool = mspecDir @@ "mspec-clr4.exe"
//  sprintf @"%sMachine.Specifications.%s\tools\mspec-clr4.exe" packagesDir MSpecVersion
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

