use BDAdvocacia
go
EXECUTE dbo.DatabaseBackup
@Databases = 'USER_DATABASES',
@Directory = 'C:\Backup',
@BackupType = 'DIFF',
@Verify = 'Y',
@CheckSum = 'Y',
@CleanupTime = 24