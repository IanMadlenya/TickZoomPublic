// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision: 2333 $</version>
// </file>

using System;
using System.Windows.Forms;
using ICSharpCode.CodeCoverage;
using NUnit.Framework;

namespace ICSharpCode.CodeCoverage.Tests
{
	/// <summary>
	/// Tests the sorting of the list view that shows
	/// the code coverage sequence points (visit counts, etc).
	/// Here we are not actually using the real list view, but
	/// just a list view which has the same number of columns.
	/// Eventually the sorter class will be replaced in
	/// SharpDevelop 3.0 with the generic sorting classes.
	/// </summary>
	[TestFixture]
	public class ListViewSortingTestFixture
	{
		ListView listView;
		CodeCoverageSequencePoint firstSequencePoint;
		CodeCoverageSequencePoint secondSequencePoint;
		SequencePointListViewSorter sorter;
		const int VisitCountColumn = 0;
		const int SequencePointLineColumn = 1;
		const int SequencePointStartColumnColumn = 2;
		const int SequencePointEndLineColumn = 3;
		const int SequencePointEndColumnColumn = 4;
		
		[SetUp]
		public void SetUp()
		{
			listView = new ListView();
			sorter = new SequencePointListViewSorter(listView);
			
			listView.Columns.Add("Visit Count");
			listView.Columns.Add("Line");
			listView.Columns.Add("Column");
			listView.Columns.Add("End Line");
			listView.Columns.Add("End Column");
			
			// Add first sequence point.
			firstSequencePoint = new CodeCoverageSequencePoint(String.Empty, 1, 5, 1, 5, 10);
			ListViewItem item = new ListViewItem("First");
			item.Tag = firstSequencePoint;
			listView.Items.Add(item);
			
			// Add second sequence point.
			secondSequencePoint = new CodeCoverageSequencePoint(String.Empty, 0, 10, 2, 10, 8);
			item = new ListViewItem("Second");
			item.Tag = secondSequencePoint;
			listView.Items.Add(item);
			
			// Need to create the control's handle otherwise
			// the list view will not sort.
			listView.CreateControl();
		}
		
		[TearDown]
		public void TearDown()
		{
			listView.Dispose();
		}
		
		[Test]
		public void InitialOrderSameAsOrderAdded()
		{
			Assert.AreSame(firstSequencePoint, listView.Items[0].Tag);
			Assert.AreSame(secondSequencePoint, listView.Items[1].Tag);
		}
		
		[Test]
		public void SortVisitCountColumn()
		{
			sorter.Sort(VisitCountColumn);
			Assert.AreSame(secondSequencePoint, listView.Items[0].Tag);
		}
		
		[Test]
		public void SortVisitCountColumnTwice()
		{
			sorter.Sort(VisitCountColumn);
			sorter.Sort(VisitCountColumn);
			Assert.AreSame(firstSequencePoint, listView.Items[0].Tag);
		}
		
		[Test]
		public void SortLineColumnTwice()
		{
			sorter.Sort(SequencePointLineColumn);
			sorter.Sort(SequencePointLineColumn);
			Assert.AreSame(secondSequencePoint, listView.Items[0].Tag);	
		}
		
		[Test]
		public void SortStartColumnTwice()
		{
			sorter.Sort(SequencePointStartColumnColumn);
			sorter.Sort(SequencePointStartColumnColumn);
			Assert.AreSame(secondSequencePoint, listView.Items[0].Tag);	
		}
		
		[Test]
		public void SortEndLineTwice()
		{
			sorter.Sort(SequencePointEndLineColumn);
			sorter.Sort(SequencePointEndLineColumn);
			Assert.AreSame(secondSequencePoint, listView.Items[0].Tag);	
		}
		
		[Test]
		public void SortEndColumn()
		{
			sorter.Sort(SequencePointEndColumnColumn);
			Assert.AreSame(secondSequencePoint, listView.Items[0].Tag);	
		}
		
		[Test]
		public void CompareNulls()
		{
			Assert.AreEqual(0, sorter.Compare(null, null));
		}
		
		[Test]
		public void CompareNullRhs()
		{
			Assert.AreEqual(0, sorter.Compare(null, new ListViewItem()));
		}
		
		[Test]
		public void CompareTwoListViewItemsWithNoTags()
		{
			sorter.Sort(VisitCountColumn);
			Assert.AreEqual(0, sorter.Compare(new ListViewItem(), new ListViewItem()));
		}
		
		[Test]
		public void CompareRhsListViewItemWithNoTag()
		{
			sorter.Sort(VisitCountColumn);
			Assert.AreEqual(0, sorter.Compare(listView.Items[0], new ListViewItem()));
		}
		
		[Test]
		public void SecondarySortByLineWhenVisitCountSame()
		{
			sorter.Sort(VisitCountColumn);
			CodeCoverageSequencePoint pt1 = new CodeCoverageSequencePoint(String.Empty, 0, 1, 0, 0, 0);
			CodeCoverageSequencePoint pt2 = new CodeCoverageSequencePoint(String.Empty, 0, 2, 0, 0, 0);
			
			ListViewItem item1 = new ListViewItem();
			item1.Tag = pt1;
			ListViewItem item2 = new ListViewItem();
			item2.Tag = pt2;
			
			Assert.AreEqual(-1, sorter.Compare(item1, item2));
		}
	}
}
