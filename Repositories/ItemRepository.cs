using System.Data;
using HuntAPI.Data;
using HuntAPI.Models;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories;

public class ItemRepository : IItemRepository
{

        private readonly HuntContext _context;
    public ItemRepository(HuntContext context)
    {
            _context = context;
    }

    public async Task<Item> Add(Item item)
    {
        if (item == null)
        {
            throw new Exception("Item Invalido");
        }
        var entity = await _context.Itens.AddAsync(item);
        await _context.SaveChangesAsync();
        return entity.Entity;
    }


    public async Task<Item> Delete(int  itemID)
    {
        var ExistingItens = await _context.Itens.FindAsync(itemID);
        if (ExistingItens == null){
            throw new Exception("Item nao Encontrado");
        }
         _context.Remove(ExistingItens);
        await _context.SaveChangesAsync();
        return ExistingItens;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Item>> GetAll()
    {
        var Itens = await _context.Itens.ToListAsync();
        if (Itens == null){
            throw new Exception("Nao existe itens");
        }

        return Itens;
    }

    public async Task<Item?> GetByID(int id)
    {
        var item = await _context.Itens.FindAsync(id);
        if (item == null)
        {
            throw new Exception("item nao encontrado ");
        }

        return item;
    }

    public async Task<Item> Update(Item item)
    {
        var ExistingItens = await _context.Itens.FindAsync(item.Id);
        if (ExistingItens == null) 
            throw new Exception("Item nao Encontrado");
        if(!string.IsNullOrEmpty(item.Name)){
            ExistingItens.Name = item.Name;
        }
        if(item.MarketPrice.HasValue) {
            ExistingItens.MarketPrice = item.MarketPrice.Value;
        }
        await _context.SaveChangesAsync();

        return ExistingItens;
    }
}
