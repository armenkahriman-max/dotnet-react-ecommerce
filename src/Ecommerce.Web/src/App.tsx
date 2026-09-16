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

if (loading) return <p>Loading...</p>;
if (error) return <p>{error}</p>;

return (
  <main>
    <h1>Products</h1>
    {products.length === 0 ? (
      <p>No products yet.</p>
    ) : (
      <ul>
        {products.map((product)=> (
          <li key={product.id}>
            {product.name}- {product.price}
          </li>
        ))}
      </ul>
    )}
  </main>
);
}
export default App;