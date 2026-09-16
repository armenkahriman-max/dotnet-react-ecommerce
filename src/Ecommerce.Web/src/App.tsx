import { useEffect, useState } from "react";

type Product = {
id: number;
name: string;
price: number;
stock: number;
description: string;
};

function App() {
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");
  const [name, setName] = useState("");
  const [price, setPrice] = useState("");
  const [stock, setStock] = useState("");
  const [description, setDescription] = useState("");
  const [selected, setSelected] = useState<Product | null>(null);


useEffect(() =>{
  async function  loadProducts() {
    try{
      const response = await fetch("http://localhost:5161/api/products");
      if(!response.ok) {
        throw new Error("Could not load products");
      }
      const data: Product[] = await response.json();
      setProducts(data);
    }catch(err) {
      setError(err instanceof Error ? err.message : "Something went wrong");
    }finally{
      setLoading(false);
    }
  }
    loadProducts();
  
}, []);
async function handleSubmit(e: React.FormEvent) {
  e.preventDefault();
  try{
  const response = await fetch("http://localhost:5161/api/products", { 
    method: "POST",
     headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        name,
         price: Number(price),
          stock: Number(stock),
      description
    }),
   });
       if(!response.ok) {
        throw new Error("Failed to submit");
       } 
       const created:Product = await response.json();
       setProducts((current)=> [...current, created]);
       setName("");
       setPrice("");
       setStock("");
       setDescription("");
      }catch(err){
        setError(err instanceof Error ? err.message : "Something went wrong");
      }
    }
    async function loadProduct(id: number) {
      try{
        const response = await fetch(`http://localhost:5161/api/products/${id}`);
        if(!response.ok) {
          throw new Error("Could not load product");
        }
          setSelected(await response.json())
        } catch(err){
        setError(err instanceof Error ? err.message : "Something went wrong");
        }
    }
    async function deleteProduct(id: number) {
      try{
        const response = await fetch(`http://localhost:5161/api/products/${id}`, {
          method:"DELETE",
        });
        if(!response.ok) {
          throw new Error("Could not delete product");
        }
        setProducts((current) => current.filter((product) => product.id !== id));
        setSelected(null);
      }catch(err) {
        setError(err instanceof Error ? err.message : "Something went wrong");
      }
    }
    
      
  
    
if (loading) return <p>Loading...</p>;

return (
  <main>
    <h1>Products</h1>
    {error && <p>{error}</p>}
    {products.length === 0 ? (
      <p>No products yet.</p>
    ) : (
      <ul>
        {products.map((product)=> (
          <li key={product.id} onClick={() => loadProduct(product.id)}>
            {product.name}- {product.price}
          </li>
        ))}
        </ul>
    )}

        {selected && ( 
       <section>
       <h2>{selected.name}</h2>
       <p>{selected.price}</p>
        <p>Stock:{selected.stock}</p>
        <p>{selected.description}</p>
        <button type="button" onClick={() => deleteProduct(selected.id)}>Delete</button>
        </section>
        
    )}

      <form onSubmit={handleSubmit}>
        <input
        value={name}
        onChange={(e) => setName(e.target.value)}
        placeholder="Name"
        />
        <input
        type="number"
        value={price}
        onChange={(e) => setPrice(e.target.value)}
        placeholder="Price"
        />
        <input
        type="number"
        value={stock}
        onChange={(e) => setStock(e.target.value)}
        placeholder="Stock"
        />
        <input
        value={description}
        onChange={(e) => setDescription(e.target.value)}
        placeholder="Description"
        />
        <button type="submit">Add product</button>
      </form>
  </main>
 
);
}
export default App;