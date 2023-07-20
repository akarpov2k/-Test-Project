using Microsoft.EntityFrameworkCore;
using Spargo_Technology_Test_Project.Models;
using Spargo_Technology_Test_Project.Models.Data_models;
using Spargo_Technology_Test_Project.Models.Errors;
using Spargo_Technology_Test_Project.Models.ViewModels;

namespace Spargo_Technology_Test_Project.Services
{
    public interface IDataService
    {
        public Guid CreateBatch(BatchModel model);
        public IEnumerable<BatchModel> GetAllBatch();
        public BatchModel GetBatchByStockId(Guid stockId);
        public void DeleteBatch(Guid batchId);

        public Guid CreatePharmacy(PharmacyModel model);
        public IEnumerable<PharmacyModel> GetAllPharmacy();
        public PharmacyModel GetPharmacyById(Guid pharmacyId);
        public void DeletePharmacy(Guid pharmacyId);

        public Guid CreateProduct(ProductModel model);
        public ProductModel GetProductById(Guid productId);
        public IEnumerable<ProductModel> GetProductsByPharmacyId(Guid pharmacyId);
        public IEnumerable<ProductModel> GetAllProducts();
        public void DeleteProduct(Guid productId);

        public IEnumerable<StockModel> GetAllStocks();
        public Guid CreateStock(StockModel model);

        public void DeleteStock(Guid id);

        public IEnumerable<BatchModel> GetBatchesByStockId(Guid stockId);

    }
    public class DataService : IDataService
    {
        private readonly SpargoDataContext _spargoDataContext;

        public DataService(SpargoDataContext spargoDataContext)
        {
            _spargoDataContext = spargoDataContext;
        }

        public Guid CreateBatch(BatchModel model)
        {
            var batch = new Batch()
            {
                Count = model.Count
            };
            batch.Product = _spargoDataContext.Products.FirstOrDefault(x => x.Id == model.Product.Id);
            batch.Stock = _spargoDataContext.Stocks.FirstOrDefault(x => x.Id == model.Stock.Id);
            _spargoDataContext.Batches.Add(batch);
            _spargoDataContext.SaveChanges();
            return batch.Id;
        }

        public Guid CreatePharmacy(PharmacyModel model)
        {
            var pharmacy = new Pharmacy()
            {
                Name = model.Name.Trim(),
                Address = model.Address.Trim(),
                Phone = model.Phone.Trim()
            };
            _spargoDataContext.Pharmacy.Add(pharmacy);
            _spargoDataContext.SaveChanges();
            return pharmacy.Id;
        }

        public Guid CreateProduct(ProductModel model)
        {
            var product = new Product() { Name = model.Name };
            _spargoDataContext.Products.Add(product);
            _spargoDataContext.SaveChanges();
            return product.Id;
        }

        public Guid CreateStock(StockModel model)
        {
            var stock = new Stock()
            {
                Name = model.Name.Trim()                
            };
            var pharmacy = _spargoDataContext.Pharmacy.FirstOrDefault(x => x.Id == model.Pharmacy.Id);
            if(pharmacy == null)
            {
                throw new EntityNotFound("Такой аптеки не существует");
            }
            stock.Pharmacy = pharmacy;
            _spargoDataContext.Stocks.Add(stock);
            _spargoDataContext.SaveChanges();
            return stock.Id;
        }

        public void DeleteBatch(Guid batchId)
        {
            if (batchId != Guid.Empty)
            {
                var batch = _spargoDataContext.Batches.FirstOrDefault(x => x.Id == batchId);
                if (batch != null)
                {
                    _spargoDataContext.Batches.Remove(batch);
                    _spargoDataContext.SaveChanges();
                }
                else
                {
                    throw new EntityNotFound($"Не найдена партия с идентификатором id={batchId}");
                }
            }
        }

        public void DeletePharmacy(Guid pharmacyId)
        {
            if (pharmacyId != Guid.Empty)
            {
                var pharmacy = _spargoDataContext.Pharmacy.FirstOrDefault(x => x.Id == pharmacyId);
                if (pharmacy != null)
                {
                    _spargoDataContext.Pharmacy.Remove(pharmacy);
                    var stocks = _spargoDataContext.Stocks.Where(x => x.Id == pharmacyId);
                    foreach (var stock in stocks)
                    {
                        var batch = _spargoDataContext.Batches.FirstOrDefault(x => x.Stock.Id == stock.Id);
                        if (batch != null)
                        {
                            _spargoDataContext.Batches.Remove(batch);
                        }
                        _spargoDataContext.Stocks.RemoveRange(stocks);
                    }
                    _spargoDataContext.SaveChanges();
                }
                else
                {
                    throw new EntityNotFound($"Не найдена аптека с идентификатором id={pharmacy.Id}");
                }

            }
        }

        public void DeleteProduct(Guid productId)
        {
            if (productId != Guid.Empty)
            {
                var product = _spargoDataContext.Products.FirstOrDefault(x => x.Id == productId);
                if (product != null)
                {
                    var batches = _spargoDataContext.Batches
                        .Where(x => x.Product.Id == productId);
                    _spargoDataContext.Batches.UpdateRange(batches);
                    _spargoDataContext.Products.Remove(product);
                    _spargoDataContext.SaveChanges();
                }
                else
                {
                    throw new EntityNotFound($"Не найден товар с идентификатором id={productId}");
                }
            }
        }

        public void DeleteStock(Guid id)
        {
            if (id != Guid.Empty)
            {
                var stock = _spargoDataContext.Stocks.FirstOrDefault(x => x.Id == id);
                if(stock != null)
                {
                    var batches = _spargoDataContext.Batches.Where(x => x.Stock.Id == stock.Id);
                    _spargoDataContext.Batches.RemoveRange(batches);
                    _spargoDataContext.Stocks.Remove(stock);
                    _spargoDataContext.SaveChanges();
                }
                else
                {
                    throw new EntityNotFound($"Не найден склад с идентификатором id={id}");
                }
            }
        }

        public IEnumerable<BatchModel> GetAllBatch()
        {
            return _spargoDataContext.Batches
                .Select(x => new BatchModel() {
                    Id = x.Id,
                    Count = x.Count,
                    Product = new ProductModel() { Id = x.Product.Id,Name = x.Product.Name},
                    Stock = new StockModel() { Id = x.Stock.Id, Name = x.Stock.Name}
                })
                .ToList();
        }

        public IEnumerable<PharmacyModel> GetAllPharmacy()
        {
            return _spargoDataContext.Pharmacy
                .Select(x => new PharmacyModel() { Id = x.Id, Address = x.Address, Name = x.Name, Phone = x.Phone })
                .ToList();
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            return _spargoDataContext.Products
                .Select(x => new ProductModel() { Id = x.Id, Name = x.Name })
                .ToList();
        }

        public IEnumerable<StockModel> GetAllStocks()
        {
            return _spargoDataContext.Stocks
                .Select(x => new StockModel() { Id = x.Id, Name = x.Name, Pharmacy = new PharmacyModel() { Id = x.Pharmacy.Id, Name = x.Pharmacy.Name } })
            .ToList();
        }

        public BatchModel GetBatchByStockId(Guid stockId)
        {
            var batch = _spargoDataContext.Batches.FirstOrDefault(x => x.Stock.Id == stockId);
            if (batch == null)
            {
                throw new EntityNotFound($"Не найдена запись с id = {stockId}");
            }
            var res = new BatchModel()
            {
                Id = batch.Id,
                Count = batch.Count,
                Product = new ProductModel()
                {
                    Id = batch.Product.Id,
                    Name = batch.Product.Name
                },
                Stock = new StockModel()
                {
                    Id = batch.Stock.Id,
                    Name = batch.Stock.Name
                }
            };
            return res;
        }

        public IEnumerable<BatchModel> GetBatchesByStockId(Guid stockId)
        {
            return _spargoDataContext.Batches
                .Include(x => x.Product)
                .Include(x => x.Stock)
                .Where(x => x.Stock.Id == stockId)
                .Select(x => new BatchModel()
                {
                    Id = x.Id,
                    Count = x.Count,
                    Product =new ProductModel()
                    {
                        Id = x.Product.Id,
                        Name = x.Product.Name
                    },
                    Stock = new StockModel()
                    {
                        Id = x.Stock.Id,
                        Name =x.Stock.Name
                    }
                })
                .ToList();
            
        }

        public PharmacyModel GetPharmacyById(Guid pharmacyId)
        {
            throw new NotImplementedException();
        }

        public ProductModel GetProductById(Guid productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductModel> GetProductsByPharmacyId(Guid pharmacyId)
        {
            var batches = _spargoDataContext.Batches
                .Include(x => x.Product)
                .Include(x => x.Stock)
                .Where(x => x.Stock.Pharmacy.Id == pharmacyId)
                .ToList();
            var products = new List<ProductModel>();
            foreach (var batch in batches)
            {                
                products.Add(new ProductModel() { Id = batch.Product.Id, Name = batch.Product.Name });
            }
            return products;
        }
    }
}
