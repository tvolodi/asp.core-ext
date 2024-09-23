function IncrementVersion{
	param(
		$prjDir
	)
	
	$prjVersionFile = "./" + $prjDir + "/version.txt"
	$version = Get-Content -Path $prjVersionFile
	$versionArray = $version.Split(".")
	$buildVersion = $versionArray[2]
	$buildVersion = [int]$buildVersion + 1
	$versionArray[2] = $buildVersion
	$newVersion = $versionArray -join "."
	$newVersion > $prjVersionFile
	
	return $newVersion
}

function BuildAndPublish{
	param(
		$prjDir,
		$newVersion
	)
	"---------------------"
	"Build and publish"
	"---------------------"
	$password = Get-Content -Path password.txt

	$packProjectCmd = "dotnet pack --configuration Release ./" + $prjDir + " /p:Version=" + $newVersion
	Write-Output $packProjectCmd
	
	Invoke-Expression $packProjectCmd
	"---------------------------"
	
	# Write-Output $prjDir
	
	$pushPackageCmd = "dotnet nuget push ./ServerExt/bin/Release/" + $prjDir + "." + $newVersion + ".nupkg --api-key " + $password + " --source github"
	
	Write-Output $pushPackageCmd
	
	Invoke-Expression $pushPackageCmd	
	
	"=================================="
}
	
$prjDirPathArray = "ServerExt"
# , "ClientExt", "SharedLib"

foreach ($prjDir in $prjDirPathArray) {
	
	$newVersion1 = IncrementVersion $prjDir
	
	 Write-Output "newVersion = "  $newVersion1
	
	BuildAndPublish $prjDir $newVersion1
}


