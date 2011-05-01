// Copyright 2011 ThoughtWorks, Inc. See LICENSE.txt for licensing info.
using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace FluentTime.Tests
{
	[TestFixture]
	public class DateTimeOffsettingTest
	{
		[Test]
		public void DateTime_can_be_offset_by_specified_hours ()
		{
			Assert.That(1.May(2011).At(9).Offset(-5), Is.EqualTo(new DateTimeOffset(1.May(2011).At(9), -5.Hours())));
		}

		[Test]
		public void DateTime_can_be_offset_by_specified_TimeSpan ()
		{
			Assert.That(1.May(2011).At(9).Offset(2.Hours()), Is.EqualTo(new DateTimeOffset(1.May(2011).At(9), 2.Hours())));
		}
		
		[Test]
		public void DateTime_can_be_offset_for_a_given_system_time_zone_identifier ()
		{
			Assert.That(1.May(2011).At(4, 23).PM().OffsetFor("US/Eastern"),
			            Is.EqualTo(new DateTimeOffset(1.May(2011).At(4, 23).PM(), -4.Hours())));
		}
		
		[Test]
		public void DateTime_can_be_offset_for_a_given_TimeZoneInfo()
		{
			var easternTime = TimeZoneInfo.FindSystemTimeZoneById("US/Eastern");
			Assert.That(1.May(2011).At(4, 23).PM().OffsetFor(easternTime),
			            Is.EqualTo(new DateTimeOffset(1.May(2011).At(4, 23).PM(), -4.Hours())));
		}
	}
}

