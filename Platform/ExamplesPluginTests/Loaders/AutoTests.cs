#region Copyright
/*
 * Software: TickZoom Trading Platform
 * Copyright 2009 M. Wayne Walter
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 * 
 * Business use restricted to 30 days except as otherwise stated in
 * in your Service Level Agreement (SLA).
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, see <http://www.tickzoom.org/wiki/Licenses>
 * or write to Free Software Foundation, Inc., 51 Franklin Street,
 * Fifth Floor, Boston, MA  02110-1301, USA.
 * 
 */
#endregion

using System;
using TickZoom.Api;
using TickZoom.Common;
using TickZoom.Examples;

namespace Loaders
{
	[AutoTestFixture]
	public class AutoTests : IAutoTestFixture {
		public AutoTestMode GetModesToRun() {
			return AutoTestMode.Default | AutoTestMode.FIXPlayBack;
		}
		public AutoTestSettings[] GetAutoTestSettings() {
			var list = new System.Collections.Generic.List<AutoTestSettings>();
			var storeKnownGood = false;
			var showCharts = false;
			var primarySymbol = "USD/JPY";
			try { 
				list.Add( new AutoTestSettings {
				    Mode = AutoTestMode.Default,
				    Name = "ApexStrategyTest",
				    Loader = Plugins.Instance.GetLoader("APX_Systems: APX Multi-Symbol Loader"),
					Symbols = primarySymbol + ",EUR/USD,USD/CHF",
					StoreKnownGood = storeKnownGood,
					ShowCharts = showCharts,
					StartTime = new TimeStamp( 1800, 1, 1),
					EndTime = new TimeStamp( 2009, 6, 10),
					IntervalDefault = Intervals.Minute1,
				});
			} catch( ApplicationException ex) {
				if( !ex.Message.Contains("not found")) {
					throw;
				}
			}
			
			try { 
				list.Add( new AutoTestSettings {
				    Mode = AutoTestMode.Default,
				    Name = "Apex_NQ_MeltdownTest",
				    Loader = Plugins.Instance.GetLoader("APX_Systems: APX Multi-Symbol Loader"),
				    Symbols = "/NQU0",
					StoreKnownGood = storeKnownGood,
					ShowCharts = showCharts,
					StartTime = new TimeStamp( 1800, 1, 1),
					EndTime = new TimeStamp( "2010-08-25 15:00:00"),
					IntervalDefault = Intervals.Second10,
				});
			} catch( ApplicationException ex) {
				if( !ex.Message.Contains("not found")) {
					throw;
				}
			}
			
			try { 
				list.Add( new AutoTestSettings {
				    Mode = AutoTestMode.Default,
				    Name = "ApexMeltdownTest",
				    Loader = Plugins.Instance.GetLoader("APX_Systems: APX Multi-Symbol Loader"),
				    Symbols = "GE,INTC",
					StoreKnownGood = storeKnownGood,
					ShowCharts = showCharts,
					StartTime = new TimeStamp( 1800, 1, 1),
					EndTime = new TimeStamp( "2010-09-22 15:00:00"),
					IntervalDefault = Intervals.Second10,
				});
			} catch( ApplicationException ex) {
				if( !ex.Message.Contains("not found")) {
					throw;
				}
			}

            list.Add(new AutoTestSettings
            {
                Mode = AutoTestMode.Default,
                Name = "ExampleBreakoutReversalTest",
                Loader = new ExampleBreakoutReversalLoader(),
                Symbols = "USD/JPY",
                StoreKnownGood = storeKnownGood,
                ShowCharts = showCharts,
                StartTime = new TimeStamp(1800, 1, 1),
                EndTime = new TimeStamp(2009, 6, 22),
                IntervalDefault = Intervals.Minute1,
            });

            list.Add(new AutoTestSettings
            {
			    Mode = AutoTestMode.Default,
			    Name = "DualStrategyLimitOrder",
			    Loader = new TestDualStrategyLoader(),
				Symbols = primarySymbol + ",EUR/USD",
				StoreKnownGood = storeKnownGood,
				ShowCharts = showCharts,
				StartTime = new TimeStamp( 1800, 1, 1),
				EndTime = new TimeStamp( 2009, 6, 10),
				IntervalDefault = Intervals.Minute1,
			});
			
			list.Add( new AutoTestSettings {
			    Mode = AutoTestMode.Historical,
			    Name = "ExampleDualStrategyTest",
			    Loader = new ExampleDualStrategyLoader(),
				Symbols = "Daily4Sim",
				StoreKnownGood = storeKnownGood,
				ShowCharts = showCharts,
				StartTime = new TimeStamp( 1800, 1, 1),
				EndTime = new TimeStamp( 1990, 1, 1),
				IntervalDefault = Intervals.Day1,
			});
			
			list.Add( new AutoTestSettings {
			    Mode = AutoTestMode.Default,
			    Name = "LimitOrderTest",
			    Loader = new TestLimitOrderLoader(),
				Symbols = primarySymbol,
				StoreKnownGood = storeKnownGood,
				ShowCharts = showCharts,
				StartTime = new TimeStamp( 1800, 1, 1),
				EndTime = new TimeStamp( 2009, 6, 10),
				IntervalDefault = Intervals.Minute1,
			});
			
			list.Add( new AutoTestSettings {
			    Mode = AutoTestMode.Default,
			    Name = "MarketOrderTest",
			    Loader = new MarketOrderLoader(),
				Symbols = primarySymbol,
				StoreKnownGood = storeKnownGood,
				ShowCharts = showCharts,
				StartTime = new TimeStamp( 1800, 1, 1),
				EndTime = new TimeStamp( 2009, 6, 10),
				IntervalDefault = Intervals.Minute1,
			});
			
			list.Add( new AutoTestSettings {
			    Mode = AutoTestMode.Default,
			    Name = "SyntheticMarketOrderTest",
			    Loader = new MarketOrderLoader(),
				Symbols = "USD/JPY_Synthetic",
				StoreKnownGood = storeKnownGood,
				ShowCharts = showCharts,
				StartTime = new TimeStamp( 1800, 1, 1),
				EndTime = new TimeStamp( 2009, 6, 10),
				IntervalDefault = Intervals.Minute1,
			});
			
			list.Add( new AutoTestSettings {
			    Mode = AutoTestMode.Historical,
			    Name = "ExampleReversalOnSimData",
			    Loader = new ExampleReversalLoader(),
				Symbols = "Daily4Sim",
				StoreKnownGood = storeKnownGood,
				ShowCharts = showCharts,
				StartTime = new TimeStamp(1800,1,1),
				EndTime = new TimeStamp(1990,1,1),
				IntervalDefault = Intervals.Day1,
			});
			
			list.Add( new AutoTestSettings {
			    Mode = AutoTestMode.Historical,
			    Name = "ExampleMixedSimulated",
			    Loader = new ExampleMixedLoader(),
				Symbols = "FullTick,Daily4Sim",
				StoreKnownGood = storeKnownGood,
				ShowCharts = showCharts,
				StartTime = new TimeStamp(1800,1,1),
				EndTime = new TimeStamp(1990,1,1),
				IntervalDefault = Intervals.Day1,
			});
			
			list.Add( new AutoTestSettings {
			    Mode = AutoTestMode.Historical | AutoTestMode.SimulateFIX,
			    Name = "ExampleMixedTest",
			    Loader = new ExampleMixedLoader(),
				Symbols = primarySymbol + ",EUR/USD,USD/CHF",
				StoreKnownGood = storeKnownGood,
				ShowCharts = showCharts,
				StartTime = new TimeStamp( 1800, 1, 1),
				EndTime = new TimeStamp( 2009, 6, 10),
				IntervalDefault = Intervals.Minute1,
				Categories = { "Failed" },
			});
			
			list.Add( new AutoTestSettings {
			    Mode = AutoTestMode.Default,
			    Name = "ExampleReversalTest",
			    Loader = new ExampleReversalLoader(),
				Symbols = primarySymbol,
				StoreKnownGood = storeKnownGood,
				ShowCharts = showCharts,
				StartTime = new TimeStamp( 1800, 1, 1),
				EndTime = new TimeStamp( 2009, 6, 10),
				IntervalDefault = Intervals.Minute1,
			});
			
			list.Add( new AutoTestSettings {
			    Mode = AutoTestMode.Default,
			    Name = "LimitReversalTest",
			    Loader = new LimitReversalLoader(),
				Symbols = primarySymbol,
				StoreKnownGood = storeKnownGood,
				ShowCharts = showCharts,
				StartTime = new TimeStamp( 1800, 1, 1),
				EndTime = new TimeStamp( 2009, 6, 10),
				IntervalDefault = Intervals.Minute1,
            });
			
			list.Add( new AutoTestSettings {
			    Mode = AutoTestMode.Default,
			    Name = "LimitChangeTest",
			    Loader = new LimitChangeOffsetDisabledLoader(),
				Symbols = primarySymbol,
				StoreKnownGood = storeKnownGood,
				ShowCharts = showCharts,
				StartTime = new TimeStamp( 1800, 1, 1),
				EndTime = new TimeStamp( 2009, 6, 10),
				IntervalDefault = Intervals.Minute1,
			});

            list.Add(new AutoTestSettings
            {
                Mode = AutoTestMode.Default,
                Name = "LimitChangeOffsetTest",
                Loader = new LimitChangeLoader(),
                Symbols = primarySymbol,
                StoreKnownGood = storeKnownGood,
                ShowCharts = showCharts,
                StartTime = new TimeStamp(1800, 1, 1),
                EndTime = new TimeStamp(2009, 6, 10),
                IntervalDefault = Intervals.Minute1,
            });

            // Fast Running CSCO real time tests...
			var cscoRealTime = new AutoTestSettings {
			    Mode = AutoTestMode.Default,
			    Name = "RealTimeLimitOrderTest",
			    Loader = new TestLimitOrderLoader(),
				Symbols = "CSCO",
				StoreKnownGood = storeKnownGood,
				ShowCharts = showCharts,
				EndTime = new TimeStamp( 2011,1,15,1,30,0),
				IntervalDefault = Intervals.Minute1,
			};
			list.Add(cscoRealTime);
			
			// Real time (slow running) CSCO real time test.
			cscoRealTime = cscoRealTime.Copy();
			cscoRealTime.Mode = AutoTestMode.None;
			cscoRealTime.RelativeEndTime = new Elapsed(2,0,0);
			list.Add( cscoRealTime);
			
			// Fast Running SPY real time tests...
			var spyTradeDataOnly = new AutoTestSettings {
			    Mode = AutoTestMode.Historical,
			    Name = "RealTimeSPYDataOnly",
			    Loader = new TestDataOnlyLoader(),
				Symbols = "SPYTradeOnly",
				StoreKnownGood = storeKnownGood,
				ShowCharts = showCharts,
				EndTime = new TimeStamp( 2011,2,17),
				IntervalDefault = Intervals.Second10,
			};
			list.Add(spyTradeDataOnly);
			
			// Real time (slow running) CSCO real time test.
			spyTradeDataOnly = spyTradeDataOnly.Copy();
			spyTradeDataOnly.Mode = AutoTestMode.None;
			spyTradeDataOnly.RelativeEndTime = new Elapsed(0,3,00);
			list.Add( spyTradeDataOnly);
			
			var spyQuoteDataOnly = new AutoTestSettings {
			    Mode = AutoTestMode.Historical,
			    Name = "RealTimeSPYQuoteOnly",
			    Loader = new TestDataOnlyLoader(),
				Symbols = "SPYQuoteOnly",
				StoreKnownGood = storeKnownGood,
				ShowCharts = showCharts,
				EndTime = new TimeStamp( 2021,2,17),
				IntervalDefault = Intervals.Second10,
			};
			list.Add(spyQuoteDataOnly);
			
			// Real time (slow running) CSCO real time test.
			spyQuoteDataOnly = spyQuoteDataOnly.Copy();
			spyQuoteDataOnly.Mode = AutoTestMode.None;
			spyQuoteDataOnly.RelativeEndTime = new Elapsed(0,3,00);
			list.Add( spyQuoteDataOnly);
			
			var multiSymbolOrders = new AutoTestSettings {
			    Mode = AutoTestMode.Historical,
			    Name = "MultiSymbolOrders",
			    Loader = new ExampleOrdersLoader(),
				Symbols = @"AD.1month, BO.1month, BP.1month, CC.1month, CD.1month, CL.1month,
					CN.1month, CT.1month, DJ.1month, DX.1month, EC.1month, ED.1month,
                    ER.1month, ES.1month, FC.1month, FV.1month, GC.1month, HG.1month,
                    HO.1month, JO.1month, JY.1month, KC.1month, LB.1month, LC.1month,
                    LH.1month, MD.1month, ME.1month, MG.1month, MI.1month, NG.1month,
                    NK.1month, NQ.1month, OA.1month, PA.1month, PB.1month, PL.1month,
                    SB.1month, SF.1month, SM.1month, SV.1month, SY.1month, TU.1month,
                    TY.1month, US.1month, WC.1month, XB.1month",
				StoreKnownGood = storeKnownGood,
				ShowCharts = showCharts,
				EndTime = new TimeStamp( 2010,3,3),
				IntervalDefault = Intervals.Hour1,
				Categories = { "MultiSymbolOrders" },
			};
			list.Add(multiSymbolOrders);
			
			return list.ToArray();
		}
	}
}
