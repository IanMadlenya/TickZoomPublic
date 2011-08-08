// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision: 2633 $</version>
// </file>

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ICSharpCode.SharpDevelop.Project;
using ICSharpCode.Core;

namespace ICSharpCode.SharpDevelop.Gui
{
	public class AssemblyReferencePanel : Panel, IReferencePanel
	{
		ISelectReferenceDialog selectDialog;
		
		public AssemblyReferencePanel(ISelectReferenceDialog selectDialog)
		{
			this.selectDialog = selectDialog;
			
			Button browseButton   = new Button();
			browseButton.Location = new Point(10, 10);
			
			browseButton.Text     = StringParser.Parse("${res:Global.BrowseButtonText}");
			browseButton.Click   += new EventHandler(SelectReferenceDialog);
			browseButton.FlatStyle = FlatStyle.System;
			Controls.Add(browseButton);
		}
		
		void SelectReferenceDialog(object sender, EventArgs e)
		{
			using (OpenFileDialog fdiag  = new OpenFileDialog()) {
				fdiag.AddExtension    = true;
				
				fdiag.Filter = StringParser.Parse("${res:SharpDevelop.FileFilter.AssemblyFiles}|*.dll;*.exe|${res:SharpDevelop.FileFilter.AllFiles}|*.*");
				fdiag.Multiselect     = true;
				fdiag.CheckFileExists = true;
				
				if (fdiag.ShowDialog(ICSharpCode.SharpDevelop.Gui.WorkbenchSingleton.MainForm) == DialogResult.OK) {
					foreach (string file in fdiag.FileNames) {
						ReferenceProjectItem assemblyReference = new ReferenceProjectItem(selectDialog.ConfigureProject);
						assemblyReference.Include = Path.GetFileNameWithoutExtension(file);
						assemblyReference.HintPath = FileUtility.GetRelativePath(selectDialog.ConfigureProject.Directory, file);
						
						selectDialog.AddReference(
							Path.GetFileName(file), "Assembly", file,
							assemblyReference
						);
					}
				}
			}
		}
		
		public void AddReference()
		{
			SelectReferenceDialog(null, null);
		}
	}
}
