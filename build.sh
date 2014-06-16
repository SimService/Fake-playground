#!/bin/bash
mono .nuget/NuGet.exe Install FAKE -OutputDirectory packages -ExcludeVersion
mono packages/FAKE/tools/Fake.exe build.fsx