@echo off
title IL2CPP Clean 1.6
rd /s/q .\Library\il2cpp_android_arm64-v8a
rd /s/q .\Library\il2cpp_android_armeabi-v7a
rd /s/q .\Library\il2cpp_android_x86
rd /s/q .\Library\il2cpp_android_x86_64
rd /s/q .\Library\il2cpp_cache
rd /s/q .\Library\Il2cppBuildCache
rd /s/q .\Library\Artifacts
del /f /s /q .\Library\ArtifactDB
del /f /s /q .\Library\ArtifactDB-lock
rd /s/q .\Library\ShaderCache
del /f /s /q .\Library\PackageCache
rd /s/q .\Library\PackageCache
del /f /s /q .\Library\ShaderCache.db
del /f /s /q .\Library\SourceAssetDB
del /f /s /q .\Library\SourceAssetDB-lock
del /f /s /q ".\Library\il2cpp_cache 2020.3.33f1 (915a7af8b0d5)"
del /f /s /q ".\Library\il2cpp_cache 2020.3.44f1 (7f159b6136da)"
del /f /s /q ".\Library\il2cpp_cache 2020.3.46f1 (18bc01a066b4)"
del /f /s /q ".\Library\il2cpp_cache 2018.3.0a2 (7fc052e81176)"
rd /s/q .\obj
rd /s/q .\Logs
rd /s/q .\Log
rd /s/q .\Temp
rd /s/q .\Library\PlayerDataCache
rd /s/q .\Library\ScriptAssemblies
rd /s/q .\Library\Recorder
rd /s/q .\Library\BurstCache
rd /s/q .\Library\TempArtifacts
rd /s/q .\Library\webgl_cache
rd /s/q .\Release-Win32
rd /s/q .\Release-Win64
rd /s/q .\Release-Android
del /f /s /q .\*.csproj
rd /s/q .\.vs
rd /s/q .\.vscode
del /f /s /q .\.vsconfig
del /f /s /q .\.gitignore
del /f /s /q .\.gitattributes
del /f /s /q .\.gitmodules
del /f /s /q .\*.sln
del /f /s /q .\assetbundles_output\temp\*.umtc
del /f /s /q .\assetbundles_output\temp\*.meta
del /f /s /q .\assetbundles_output\unsigned\*.assetbundle
del /f /s /q .\assetbundles_output\unsigned\*.meta
rd /s/q .\HybridCLRData\AssembliesPostIl2CppStrip\StandaloneWindows
rd /s/q .\HybridCLRData\AssembliesPostIl2CppStrip\StandaloneWindows64
rd /s/q .\HybridCLRData\AssembliesPostIl2CppStrip\Android
rd /s/q .\HybridCLRData\HotFixDlls\StandaloneWindows
rd /s/q .\HybridCLRData\HotFixDlls\StandaloneWindows64
rd /s/q .\HybridCLRData\HotFixDlls\Android
rd /s/q .\Assets\HybridCLRBuildCache\AssetBundleOutput
del /f /s /q .\Assets\HybridCLRBuildCache\AssetBundleOutput.meta
rd /s/q .\Assets\HybridCLRBuildCache\AssetBundleSourceData
del /f /s /q .\Assets\HybridCLRBuildCache\AssetBundleSourceData.meta
del /f /s /q .\Library\AnnotationManager
del /f /s /q .\Library\BuildPlayer.prefs
del /f /s /q .\Library\expandedItems
del /f /s /q .\Library\LastBuild.buildreport
del /f /s /q .\Library\ScriptMapper
del /f /s /q .\Library\Style.catalog
rd /s/q .\Library\PackageManager
rd /s/q .\Library\APIUpdater
del /q "ps_driver_sdk*.log"
rd /s/q .\Library\Bee
rd /s/q .\Library\StateCache
rd /s/q .\Library\SplashScreenCache
rd /s/q .\.utmp
for /d %%d in (*_BurstDebugInformation_DoNotShip) do rd /s /q "%%d"
exit