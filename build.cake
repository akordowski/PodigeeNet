#load nuget:https://www.myget.org/F/arkord/api/v2?package=Cake.Baker

Build
    .SetParameters(
        "PodigeeNet",
        "akordowski")
    .Run();