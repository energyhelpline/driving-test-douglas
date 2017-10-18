#tool "nuget:?package=NUnit.Runners&version=2.6.3"

var target = Argument("target", "Default");
var configuration = "Release";

Task("Run-Unit-Tests")
  .Does(() => 
  {
      var assemblies = GetFiles("**/bin/Release/**/*.Test.dll");
      foreach(var assembly in assemblies)
      {
        Information(assembly);
      }
      NUnit(assemblies);
  });

Task("Build")
  .Does(() =>
  {
    var settings = new MSBuildSettings {Configuration = "Release" };
    settings.WithTarget("Rebuild");
    MSBuild("ProNet.sln", settings);
  });

Task("Default")
  .IsDependentOn("Build")
  .IsDependentOn("Run-Unit-Tests");  

RunTarget(target);