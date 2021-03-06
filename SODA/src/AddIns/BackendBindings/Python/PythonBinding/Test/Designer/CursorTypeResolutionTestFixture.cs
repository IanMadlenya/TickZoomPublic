// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision: 3978 $</version>
// </file>

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using ICSharpCode.PythonBinding;
using IronPython.Compiler.Ast;
using NUnit.Framework;
using PythonBinding.Tests.Utils;

namespace PythonBinding.Tests.Designer
{
	/// <summary>
	/// Tests that the string "System.Windows.Forms.Cursors.AppStarting" can be resolved by the 
	/// PythonCodeDeserializer.
	/// </summary>
	[TestFixture]
	public class CursorTypeResolutionTestFixture : DeserializeAssignmentTestFixtureBase
	{
		public override string GetPythonCode()
		{
			return "self.Cursors = System.Windows.Forms.Cursors.AppStarting";
		}
		
		[Test]
		public void DeserializedObjectIsCursorsAppStarting()
		{
			Assert.AreEqual(Cursors.AppStarting, deserializedObject);
		}
		
		[Test]
		public void CursorsTypeResolved()
		{
			Assert.AreEqual("System.Windows.Forms.Cursors", base.componentCreator.LastTypeNameResolved);
		}
	}
}
