; =====================================================================
; Inno Setup Script: LushCare v26.02 Pro
; Facebook Automation & Multi-Account Growth Platform
; =====================================================================

#define MyAppName "LushCare"
#define MyAppVersion "26.02"
#define MyAppPublisher "LushCare Tech"
#define MyAppURL "https://lushcare.vip"
#define MyAppExeName "LushCare.exe"
#define SourceDir "staging_release"

[Setup]
; Unique application GUID - preserves upgrade path from earlier versions
AppId={{8B5A24D9-6A10-4F2A-97C5-6D48F0953E2A}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} v{#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName=C:\LushCare
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
OutputDir=Distributable
OutputBaseFilename=LushCare_v26.02_Setup
SetupIconFile={#SourceDir}\icons\icon.ico
Compression=lzma2/ultra64
SolidCompression=yes
WizardStyle=modern
PrivilegesRequired=admin
DisableProgramGroupPage=yes
CloseApplications=yes
RestartApplications=no
UsePreviousAppDir=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"

[Dirs]
Name: "{app}\database"; Permissions: users-full
Name: "{app}\interact"; Permissions: users-full
Name: "{app}\settings"; Permissions: users-full
Name: "{app}\profiles"; Permissions: users-full
Name: "{app}\backup"; Permissions: users-full
Name: "{app}\log"; Permissions: users-full
Name: "{app}\avatar"; Permissions: users-full

[Files]
; --- 1. Core Executables, Libraries & UI Assets (always overwrite on upgrade) ---
Source: "{#SourceDir}\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs; Excludes: "*.pdb,startup_log.txt,.playwright\*,log\*,temp\*,backups\*,profiles\*,photos\*,posts\*,database\*,interact\*,settings\*,prompt.json"

; --- 2. User Settings Protection (onlyifdoesntexist: never overwrite existing user configs) ---
Source: "{#SourceDir}\settings\*"; DestDir: "{app}\settings"; Flags: onlyifdoesntexist recursesubdirs createallsubdirs uninsneveruninstall; Excludes: "*.lic,*.pdb"; Permissions: users-full

; --- 3. Database Protection (onlyifdoesntexist: never overwrite client's account database) ---
Source: "{#SourceDir}\database\*.sqlite"; DestDir: "{app}\database"; Flags: onlyifdoesntexist uninsneveruninstall; Permissions: users-full

; --- 4. Scenarios & Action Protection (onlyifdoesntexist: never overwrite customized scripts) ---
Source: "{#SourceDir}\interact\*.sqlite"; DestDir: "{app}\interact"; Flags: onlyifdoesntexist uninsneveruninstall; Permissions: users-full

; --- 5. AI Prompt Configuration (onlyifdoesntexist: never overwrite customized prompts) ---
Source: "{#SourceDir}\prompt.json"; DestDir: "{app}"; Flags: onlyifdoesntexist uninsneveruninstall; Permissions: users-full

[Icons]
; Start Menu Shortcuts
Name: "{autoprograms}\{#MyAppName}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\icons\icon.ico"
Name: "{autoprograms}\{#MyAppName}\Gỡ cài đặt {#MyAppName}"; Filename: "{uninstallexe}"

; Desktop Shortcuts
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\icons\icon.ico"; Tasks: desktopicon

[UninstallDelete]
Type: filesandordirs; Name: "{app}\log"
Type: filesandordirs; Name: "{app}\temp"

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent shellexec
