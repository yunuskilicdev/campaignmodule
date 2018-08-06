# Campaign Module

Code sample for the campaign module with using .net core. This project was written to learn .net core and test. 

#publish

cd CampaignModuleApplication<br/>
dotnet publish -c release -r win10-x64<br/>
Exe location : CampaignModuleApplication\bin\release\netcoreapp2.1\win10-x64<br/>

# Run

cd CampaignModuleApplication<br/>
dotnet run

# Test

dotnet test

# Structure

Project consists of 3 different project.<br/>
-Class libraries(CampaignModuleService)<br/>
-Console Application(CampaignModuleApplication)<br/>
-Test(CampaignModuleService.Tests)<br/>