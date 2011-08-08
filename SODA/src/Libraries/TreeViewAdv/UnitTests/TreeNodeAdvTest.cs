// The following code was generated by Microsoft Visual Studio 2005.
// The test owner should check each test for validity.
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using Aga.Controls.Tree;
using System.Collections.ObjectModel;
namespace Aga.Controls.UnitTests
{
	/// <summary>
	///This is a test class for Aga.Controls.Tree.TreeNodeAdv and is intended
	///to contain all Aga.Controls.Tree.TreeNodeAdv Unit Tests
	///</summary>
	[TestClass()]
	public class TreeNodeAdvTest
	{


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		/// <summary>
		///A test for Nodes
		///</summary>
		[DeploymentItem("Aga.Controls.dll")]
		[TestMethod()]
		public void NodesTest()
		{
			TreeNodeAdv target = new TreeNodeAdv(null);
			Aga.Controls.UnitTests.Aga_Controls_Tree_TreeNodeAdvAccessor accessor = new Aga.Controls.UnitTests.Aga_Controls_Tree_TreeNodeAdvAccessor(target);
			Collection<TreeNodeAdv> nodes = accessor.Nodes;

			TimeCounter.Start();
			for (int i = 0; i < 125000; i++)
				nodes.Add(new TreeNodeAdv(null));
			Console.WriteLine("Add: {0}", TimeCounter.Finish());

			TimeCounter.Start();
			accessor.Nodes.Clear();
			Console.WriteLine("Clear: {0}", TimeCounter.Finish());
			Assert.AreEqual(0, accessor.Nodes.Count);
		}

	}


}
