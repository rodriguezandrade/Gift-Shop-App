export class Products {
    id: number;
    name: string;
    detail: string;
    cost: number;
    cant: number;
    status: number;
    categoryId: number;
}

export class ProductsDto extends Products {
    categoryName: string;
}

export const initialProduct: Products = {} as Products;
