// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision: 1683 $</version>
// </file>

using ICSharpCode.TextEditor.Gui.CompletionWindow;
using ICSharpCode.XmlEditor;
using NUnit.Framework;
using System;
using System.IO;
using System.Xml.Schema;
using XmlEditor.Tests.Schema;
using XmlEditor.Tests.Utils;

namespace XmlEditor.Tests.FindSchemaObject
{
	/// <summary>
	/// Tests that an xs:element/@type="prefix:name" is located in the schema.
	/// </summary>
	[TestFixture]
	public class ElementTypeWithPrefixSelectedTestFixture : SchemaTestFixtureBase
	{
		XmlSchemaComplexType schemaComplexType;
		
		public override void FixtureInit()
		{
			XmlSchemaCompletionDataCollection schemas = new XmlSchemaCompletionDataCollection();
			schemas.Add(SchemaCompletionData);
			XmlSchemaCompletionData xsdSchemaCompletionData = new XmlSchemaCompletionData(ResourceManager.GetXsdSchema());
			schemas.Add(xsdSchemaCompletionData);
			XmlCompletionDataProvider provider = new XmlCompletionDataProvider(schemas, xsdSchemaCompletionData, String.Empty);
			
			string xml = GetSchema();
			int index = xml.IndexOf("type=\"xs:complexType\"");
			index = xml.IndexOf("xs:complexType", index);
			schemaComplexType = (XmlSchemaComplexType)XmlView.GetSchemaObjectSelected(xml, index, provider, SchemaCompletionData);
		}
		
		[Test]
		public void ComplexTypeName()
		{
			Assert.AreEqual("complexType", schemaComplexType.QualifiedName.Name);
		}
		
		[Test]
		public void ComplexTypeNamespace()
		{
			Assert.AreEqual("http://www.w3.org/2001/XMLSchema", schemaComplexType.QualifiedName.Namespace);
		}
		
		protected override string GetSchema()
		{
			return "<xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" targetNamespace=\"http://www.w3schools.com\" xmlns=\"http://www.w3schools.com\" elementFormDefault=\"qualified\">\r\n" +
				"\t<xs:element name=\"note\">\r\n" +
				"\t\t<xs:complexType> \r\n" +
				"\t\t\t<xs:sequence>\r\n" +
				"\t\t\t\t<xs:element name=\"text\" type=\"xs:complexType\"/>\r\n" +
				"\t\t\t</xs:sequence>\r\n" +
				"\t\t</xs:complexType>\r\n" +
				"\t</xs:element>\r\n" +
				"</xs:schema>";
		}
	}
}
