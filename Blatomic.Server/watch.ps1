Start-Process -FilePath "npm" -ArgumentList "run watch" -WorkingDirectory "..\Blatomic.Examples"
Start-Process -FilePath "npm" -ArgumentList "run watch" -WorkingDirectory "..\Blatomic"
Start-Process -FilePath "dotnet" -ArgumentList "watch"
Exit