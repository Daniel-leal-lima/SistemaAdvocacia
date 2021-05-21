use BDAdvocacia
go
EXECUTE dbo.DatabaseBackup
@Databases = 'USER_DATABASES',
@Directory = 'C:\Backup',
@BackupType = 'FULL',
@Verify = 'Y',
@CheckSum = 'Y',
@CleanupTime = 24

