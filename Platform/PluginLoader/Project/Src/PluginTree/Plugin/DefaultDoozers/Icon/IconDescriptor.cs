﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision: 1965 $</version>
// </file>

using System;

namespace TickZoom.Loader
{
	public class IconDescriptor 
	{
		Extension codon;
		
		public string Id {
			get {
				return codon.Id;
			}
		}
		
		public string Language {
			get {
				return codon.Properties["language"];
			}
		}
		
		public string Resource {
			get {
				return codon.Properties["resource"];
			}
		}
		
		public string[] Extensions {
			get {
				return codon.Properties["extensions"].Split(';');
			}
		}
		
		public IconDescriptor(Extension codon)
		{
			this.codon = codon;
		}
	}
}