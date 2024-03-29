﻿using AutoMapper;
using Hotel.Application.Queries.RoomTypes.GetAllRoomTypes;
using Hotel.Application.Tests.Infrastructure;
using Hotel.Persistance;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Hotel.Application.Tests.Queries.RoomTypes
{
    [Collection("QueryCollection")]
    public class GetAllRoomTypesQueryHandlerTests
    {
        private readonly HotelDbContext context;
        private readonly IMapper mapper;

        public GetAllRoomTypesQueryHandlerTests(QueryTestFixture fixture)
        {
            context = fixture.Context;
            mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetAllRoomTypesTest()
        {
            var sut = new GetAllRoomTypesQueryHandler(context, mapper);

            var result = await sut.Handle(new GetAllRoomTypesQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<RoomTypeViewModel>>();
        }
    }
}
