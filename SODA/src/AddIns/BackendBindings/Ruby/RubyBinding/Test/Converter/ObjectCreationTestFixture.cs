// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision: 5343 $</version>
// </file>

using System;
using ICSharpCode.NRefactory;
using ICSharpCode.RubyBinding;
using NUnit.Framework;

namespace RubyBinding.Tests.Converter
{
	/// <summary>
	/// Tests that C# code that creates a new XmlDocument object
	/// is converted to Ruby correctly.
	/// </summary>
	[TestFixture]
	public class ObjectCreationTestFixture
	{	
		string csharp = "class Foo\r\n" +
					"{\r\n" +
					"    public Foo()\r\n" +
					"    {\r\n" +
					"        XmlDocument doc = new XmlDocument();\r\n" +
					"        doc.LoadXml(\"<root/>\");\r\n" +
					"    }\r\n" +
					"}";
		
		[Test]
		public void ConvertedRubyCode()
		{
			string expectedRuby =
				"class Foo\r\n" +
				"    def initialize()\r\n" +
				"        doc = XmlDocument.new()\r\n" +
				"        doc.LoadXml(\"<root/>\")\r\n" +
				"    end\r\n" +
				"end";
			
			NRefactoryToRubyConverter converter = new NRefactoryToRubyConverter(SupportedLanguage.CSharp);
			converter.IndentString = "    ";
			string Ruby = converter.Convert(csharp);
			
			Assert.AreEqual(expectedRuby, Ruby);
		}
	}
}
