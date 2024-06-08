//  namespace BettingSystem.Startup.Betting.Specs
//  {
//      using System.Linq;
//      using Application.Betting.Bets.Queries.Search;
//      using Domain.Betting.Models.Bets;
//      using FluentAssertions;
//      using MyTested.AspNetCore.Mvc;
//      using Web.Betting.Features;
//      using Xunit;

//      public class BetsControllerSpecs
//      {
//          [Fact]
//          public void ControllerShouldHaveCorrectAttributes()
//              => MyController<BetsController>
//                  .ShouldHave()
//                  .Attributes(attr => attr
//                      .RestrictingForAuthorizedRequests());

//          [Fact]
//          public void SearchShouldHaveCorrectAttributes()
//              => MyController<BetsController>
//                  .Calling(controller => controller
//                      .Search(With.Default<SearchBetsQuery>()))
//                  .ShouldHave()
//                  .ActionAttributes(attr => attr
//                      .RestrictingForHttpMethod(HttpMethod.Get));

//          [Theory]
//          [InlineData(10)]
//          public void SearchShouldReturnAllBetsWithoutAQuery(int totalBets)
//              => MyPipeline
//                  .Configuration()
//                  .ShouldMap("/Bets")
//                  .To<BetsController>(controller => controller
//                      .Search(With.Empty<SearchBetsQuery>()))
//                  .Which(instance => instance
//                      .WithData(BetFakes.Data.GetBets(count: totalBets)))
//                  .ShouldReturn()
//                  .ActionResult<SearchBetsResponseModel>(result => result
//                      .Passing(model => model
//                          .Bets.Count().Should().Be(totalBets)));
//      }
//  }
