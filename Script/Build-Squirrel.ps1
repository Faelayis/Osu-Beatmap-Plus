Set-Location ..\Osu.Beatmap.Plus\
$Folder = @("bin", "obj", "Publish")

foreach ($element in $Folder) {
    if (Test-Path -Path $element) {
        Remove-Item -Recurse -Force $element
    }
}

dotnet publish -p:Platform=x64 -c:Release -o:".\Publish" --self-contained false
Set-Alias Squirrel ($env:USERPROFILE + "\.nuget\packages\clowd.squirrel\2.9.42\tools\Squirrel.exe");
Squirrel pack --framework net6-x64 --packId "Osu.Beatmap.Plus" --packTitle "Osu Beatmap Plus" --packVersion "1.0.0" --packAuthors "Faelayis" --icon "./Assets/applicationIcon.ico" --packDir "./Publish" --releaseDir "../Release" --allowUnaware
pause