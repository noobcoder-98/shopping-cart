using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products;

public class Detail {
    public class Command : IRequest<Result<Product>> {
        public Guid Id { get; set; }
    }
    public class Handler : IRequestHandler<Command, Result<Product>> {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<Product>> Handle(Command request, CancellationToken cancellationToken) {
            var ret = await _context.Products!.FirstOrDefaultAsync(x => x.Id == request.Id);
            return Result<Product>.Success(ret);
        }
    }
}
