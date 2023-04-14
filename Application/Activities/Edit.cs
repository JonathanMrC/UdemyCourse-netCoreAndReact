using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest{
            public Activity Activity{get; set;}
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
            _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                //this is the one in the database
                var activitiy = await _context.Activities.FindAsync(request.Activity.Id);
                
                //?? its like an empty checker
                //activitiy.Title = request.Activity.Title ?? activitiy.Title;
                
                _mapper.Map(request.Activity, activitiy);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}