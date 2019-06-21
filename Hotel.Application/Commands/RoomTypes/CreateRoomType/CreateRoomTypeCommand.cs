﻿using Hotel.Application.Queries.RoomTypes.GetAllRoomTypes;
using MediatR;

namespace Hotel.Application.Commands.RoomTypes.CreateRoomType
{
    public class CreateRoomTypeCommand : IRequest<RoomTypeViewModel>
    {
        public string Code { get; set; }
        public int Cost { get; set; }
        public string Categories { get; set; }
        public string Facilities { get; set; }
        public int Size { get; set; }
        public string BedType { get; set; }
    }
}
