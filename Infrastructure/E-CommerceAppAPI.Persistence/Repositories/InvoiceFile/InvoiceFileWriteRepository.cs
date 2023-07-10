using E_CommerceAppAPI.Application.Repositories.InvoiceFile;
using E_CommerceAppAPI.Persistence.Contexts;

namespace E_CommerceAppAPI.Persistence.Repositories.InvoiceFile;

public class InvoiceFileWriteRepository:WriteRepository<Domain.InvoiceFile>,IInvoiceFileWriteRepository
{
    public InvoiceFileWriteRepository(ECommerceApiDbContext context) : base(context)
    {
    }
}