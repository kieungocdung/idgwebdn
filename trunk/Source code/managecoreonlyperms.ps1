param($root, $prefix, $remove)

$perms = "Read,PendChange,Checkin,Label,Lock"

$allowPaths = , ($root + "/DotNetNuke_Community.sln"),
	($root + "/DotNetNuke_Community_UnitTests.sln"),
	($root + "/BuildScripts"),
	($root + "/Deploy"),
	($root + "/DotNetNuke.Web"),
	($root + "/Library"),
	($root + "/Library/Components/DataAccessBlock"),
	($root + "/Library/Components/DocumentLibrary"),
	($root + "/Library/Components/MSAJAX"),
	($root + "/Library/Components/SearchCrawler"),
	($root + "/Library/Components/SharpZipLib"),
	($root + "/Library/Components/Syndication"),
	($root + "/Library/Components/Telerik"),
	($root + "/Library/Components/WebFormsMvp"),
	($root + "/Modules/HTML"),
	($root + "/Modules/Messaging"),
	($root + "/Modules/Taxonomy"),
	($root + "/Symbols"),
	($root + "/Tests/DotNetNuke.gallio"),
	($root + "/Tests/TestCleanup.cmd"),
	($root + "/Tests/DotNetNuke.Tests.Content"),
	($root + "/Tests/DotNetNuke.Tests.Core"),
	($root + "/Tests/DotNetNuke.Tests.Data"),
	($root + "/Tests/DotNetNuke.Tests.UI"),
	($root + "/Tests/DotNetNuke.Tests.Utilities"),
	($root + "/Tests/Externals"),
	($root + "/Tools/CCNet"),
	($root + "/Tools/MSBuild"),
	($root + "/Tools/NDepend"),
	($root + "/Website")


$denyPaths = ($root + "/Library/Components"), 
	($root + "/Library/Components/Telerik/bin/Telerik.Web.Design.dll")

if ($remove)
{
  foreach($path in $allowPaths)
  {
    tf permission /remove:* /group:"[$prefix]\Core Only" $path
  }

  foreach($path in $denyPaths)
  {
    tf permission /remove:* /group:"[$prefix]\Core Only" $path
  }
}
else
{
  foreach($path in $allowPaths)
  {
    tf permission /allow:$perms /group:"[$prefix]\Core Only" $path
  }

  foreach($path in $denyPaths)
  {
    tf permission /deny:$perms /group:"[$prefix]\Core Only" $path
  }
}
