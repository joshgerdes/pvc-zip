pvc.Task("nuget-push", () => {
	// configure NuGet
	PvcNuGet.ApiKey = Environment.GetEnvironmentVariable("NugetApiKey");

    pvc.Source("src/Pvc.Zip.csproj")
       .Pipe(new PvcNuGetPack(
            createSymbolsPackage: true
       ))
       .Pipe(new PvcNuGetPush());
});
