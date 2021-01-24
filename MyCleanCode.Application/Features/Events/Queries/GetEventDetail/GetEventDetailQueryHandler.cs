﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyCleanCode.Domain.Entities;
using MyCleanCode.Persistence;

namespace MyCleanCode.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly CleanCodeContext _cleanCodeContext;

        public GetEventDetailQueryHandler(IMapper mapper, CleanCodeContext cleanCodeContext)
        {
            _mapper = mapper;
            _cleanCodeContext = cleanCodeContext;
       }
        public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var @event = await _cleanCodeContext.Events.FindAsync(request.EventId);
            var eventDetailDto = _mapper.Map<EventDetailVm>(@event);

            return eventDetailDto;
        }
    }
}