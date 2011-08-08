// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision: 2785 $</version>
// </file>

using ICSharpCode.WixBinding;
using NUnit.Framework;
using System;
using System.IO;
using System.Xml;

namespace WixBinding.Tests.Document
{
	/// <summary>
	/// Tests that the virtual directory (the top most one) is not located in a wix file
	/// where the Directory element is not inside a Package element.
	/// </summary>
	[TestFixture]
	public class NoPackageDirectoryTestFixture
	{				
		[Test]
		public void NoDirectoryFound()
		{
			WixDocument doc = new WixDocument();
			doc.LoadXml(GetWixXml());
			Assert.IsNull(doc.RootDirectory);
		}
		
		string GetWixXml()
		{
			return "<Wix xmlns='http://schemas.microsoft.com/wix/2006/wi'>\r\n" +
				"\t<Product Name='DialogTest' \r\n" +
				"\t         Version='1.0' \r\n" +
				"\t         Language='1013' \r\n" +
				"\t         Manufacturer='#develop' \r\n" +
				"\t         Id='????????-????-????-????-????????????'>\r\n" +
				"\t\t<Fragment>\r\n" +
				"\t\t\t<Directory Id=\"TARGETDIR\" SourceName=\"SourceDir\"/>\r\n" +
				"\t\t</Fragment>\r\n" +
				"\t</Product>\r\n" +
				"</Wix>";
		}
	}
}
