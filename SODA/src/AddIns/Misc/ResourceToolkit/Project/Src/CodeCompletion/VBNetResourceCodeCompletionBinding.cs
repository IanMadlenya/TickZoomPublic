// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Christian Hornung" email=""/>
//     <version>$Revision: 1966 $</version>
// </file>

using System;
using ICSharpCode.NRefactory.PrettyPrinter;
using ICSharpCode.SharpDevelop.DefaultEditor.Gui.Editor;

namespace Hornung.ResourceToolkit.CodeCompletion
{
	/// <summary>
	/// Provides code completion for inserting resource keys in VB.
	/// </summary>
	public class VBNetResourceCodeCompletionBinding : AbstractNRefactoryResourceCodeCompletionBinding
	{
		
		/// <summary>
		/// Determines if the specified character should trigger resource resolve attempt and possibly code completion at the current position.
		/// </summary>
		protected override bool CompletionPossible(SharpDevelopTextAreaControl editor, char ch)
		{
			return ch == '(';
		}
		
		/// <summary>
		/// Gets a VBNetOutputVisitor used to generate the inserted code.
		/// </summary>
		protected override IOutputAstVisitor OutputVisitor {
			get {
				return new VBNetOutputVisitor();
			}
		}
		
	}
}
