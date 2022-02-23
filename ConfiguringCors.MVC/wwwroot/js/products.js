const createListWithInnerHtml = (products) => {
    const productList = document.getElementById("product-list");
    const rows = products.map(product => {
        return `
<div class="card" style="min-width:200px;margin:5px">
    <div class="card-body">
        <p class="card-text">${product.name}</p>
        <p class="card-text">${product.price}</p>
    </div>
</div>
`
    });
    const html = rows.join();
    productList.innerHTML = html;
}

const loadProducts = async () => {
    const response = await fetch('https://localhost:5001/api/products');
    const products = await response.json();
    createListWithInnerHtml(products)
}
