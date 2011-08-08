// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision: 4687 $</version>
// </file>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Windows.Forms;
using ICSharpCode.PythonBinding;
using NUnit.Framework;
using PythonBinding.Tests.Utils;

namespace PythonBinding.Tests.Designer
{
	[TestFixture]
	public class GenerateListViewWithImageListFormTestFixture
	{
		string generatedPythonCode;

		[TestFixtureSetUp]
		public void SetUpFixture()
		{
			using (DesignSurface designSurface = new DesignSurface(typeof(Form))) {
				IDesignerHost host = (IDesignerHost)designSurface.GetService(typeof(IDesignerHost));
				IEventBindingService eventBindingService = new MockEventBindingService(host);
				Form form = (Form)host.RootComponent;
				form.ClientSize = new Size(200, 300);

				PropertyDescriptorCollection descriptors = TypeDescriptor.GetProperties(form);
				PropertyDescriptor namePropertyDescriptor = descriptors.Find("Name", false);
				namePropertyDescriptor.SetValue(form, "MainForm");
				
				// Add list view.
				ListView listView = (ListView)host.CreateComponent(typeof(ListView), "listView1");
				listView.TabIndex = 0;
				listView.Location = new Point(0, 0);
				listView.ClientSize = new Size(200, 100);
				descriptors = TypeDescriptor.GetProperties(listView);
				PropertyDescriptor descriptor = descriptors.Find("UseCompatibleStateImageBehavior", false);
				descriptor.SetValue(listView, true);
				descriptor = descriptors.Find("View", false);
				descriptor.SetValue(listView, View.Details);
				form.Controls.Add(listView);
				
				// Add ImageList.
				Icon icon = new Icon(typeof(GenerateFormResourceTestFixture), "App.ico");
				ImageList imageList = (ImageList)host.CreateComponent(typeof(ImageList), "imageList1");
				imageList.Images.Add("App.ico", icon);
				imageList.Images.Add("b.ico", icon);
				imageList.Images.Add("c.ico", icon); 
				
				DesignerSerializationManager designerSerializationManager = new DesignerSerializationManager(host);
				IDesignerSerializationManager serializationManager = (IDesignerSerializationManager)designerSerializationManager;
				using (designerSerializationManager.CreateSession()) {					
					// Add list view items.
					ListViewItem item = (ListViewItem)serializationManager.CreateInstance(typeof(ListViewItem), new object[] {"aaa"}, "listViewItem1", false);
					item.ImageIndex = 1;
					listView.Items.Add(item);
					
					ListViewItem item2 = (ListViewItem)serializationManager.CreateInstance(typeof(ListViewItem), new object[] {"bbb"}, "listViewItem2", false);
					item2.ImageKey = "App.ico";
					listView.Items.Add(item2);
					
					ListViewItem item3 = (ListViewItem)serializationManager.CreateInstance(typeof(ListViewItem), new object[0], "listViewItem3", false);
					item3.ImageIndex = 2;
					listView.Items.Add(item3);
	
					ListViewItem item4 = (ListViewItem)serializationManager.CreateInstance(typeof(ListViewItem), new object[0], "listViewItem4", false);
					item4.ImageKey = "b.ico";
					listView.Items.Add(item4);
				
					PythonCodeDomSerializer serializer = new PythonCodeDomSerializer("    ");
					generatedPythonCode = serializer.GenerateInitializeComponentMethodBody(host, serializationManager);
				}
			}
		}
				
		/// <summary>
		/// Should include the column header and list view item creation.
		/// </summary>
		[Test]
		public void GenerateCode()
		{
			string expectedCode = "self._components = System.ComponentModel.Container()\r\n" +
								"listViewItem1 = System.Windows.Forms.ListViewItem(\"aaa\", 1)\r\n" +
								"listViewItem2 = System.Windows.Forms.ListViewItem(\"bbb\", \"App.ico\")\r\n" +
								"listViewItem3 = System.Windows.Forms.ListViewItem(\"\", 2)\r\n" +
								"listViewItem4 = System.Windows.Forms.ListViewItem(\"\", \"b.ico\")\r\n" +
								"resources = System.Resources.ResourceManager(\"MainForm\", System.Reflection.Assembly.GetEntryAssembly())\r\n" +
								"self._listView1 = System.Windows.Forms.ListView()\r\n" +
								"self._imageList1 = System.Windows.Forms.ImageList(self._components)\r\n" +
								"self.SuspendLayout()\r\n" +
								"# \r\n" +
								"# listView1\r\n" +
								"# \r\n" +
								"self._listView1.Items.AddRange(System.Array[System.Windows.Forms.ListViewItem](\r\n" +
								"    [listViewItem1,\r\n" +
								"    listViewItem2,\r\n" +
								"    listViewItem3,\r\n" +
								"    listViewItem4]))\r\n" +
								"self._listView1.Location = System.Drawing.Point(0, 0)\r\n" +
								"self._listView1.Name = \"listView1\"\r\n" +
								"self._listView1.Size = System.Drawing.Size(204, 104)\r\n" +
								"self._listView1.TabIndex = 0\r\n" +
								"self._listView1.View = System.Windows.Forms.View.Details\r\n" +
								"# \r\n" +
								"# imageList1\r\n" +
								"# \r\n" +
								"self._imageList1.ImageStream = resources.GetObject(\"imageList1.ImageStream\")\r\n" +
								"self._imageList1.TransparentColor = System.Drawing.Color.Transparent\r\n" +
								"self._imageList1.Images.SetKeyName(0, \"App.ico\")\r\n" +
								"self._imageList1.Images.SetKeyName(1, \"b.ico\")\r\n" +
								"self._imageList1.Images.SetKeyName(2, \"c.ico\")\r\n" +
								"# \r\n" +
								"# MainForm\r\n" +
								"# \r\n" +
								"self.ClientSize = System.Drawing.Size(200, 300)\r\n" +
								"self.Controls.Add(self._listView1)\r\n" +
								"self.Name = \"MainForm\"\r\n" +
								"self.ResumeLayout(False)\r\n";				
			Assert.AreEqual(expectedCode, generatedPythonCode, generatedPythonCode);
		}
	}
}
