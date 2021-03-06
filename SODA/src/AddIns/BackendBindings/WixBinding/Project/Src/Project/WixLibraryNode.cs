// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision: 1965 $</version>
// </file>

using System;
using System.IO;
using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.SharpDevelop.Project;

namespace ICSharpCode.WixBinding
{
	/// <summary>
	/// Tree node displayed in project browser that represents a WixLibrary project item. 
	/// </summary>
	public class WixLibraryNode : AbstractProjectBrowserTreeNode
	{
		WixLibraryProjectItem projectItem;
		
		public WixLibraryNode(WixLibraryProjectItem projectItem)
		{
			Text = Path.GetFileName(projectItem.Include);
			this.projectItem = projectItem;
			ContextmenuAddinTreePath = "/SharpDevelop/Pads/ProjectBrowser/ContextMenu/WixLibraryNode";
			SetIcon("Icons.16x16.Library");
		}
		
		public override object AcceptVisitor(ProjectBrowserTreeNodeVisitor visitor, object data)
		{
			return visitor.Visit(this, data);
		}
		
		public override bool EnableDelete {
			get {
				return true;
			}
		}
		
		public override void Delete()
		{
			IProject project = projectItem.Project;
			ProjectService.RemoveProjectItem(project, projectItem);
			((ExtTreeNode)Parent).Refresh();
			project.Save();
		}
	}
}
