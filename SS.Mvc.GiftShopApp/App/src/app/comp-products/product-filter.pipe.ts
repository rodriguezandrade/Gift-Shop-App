import { PipeTransform, Pipe } from '@angular/core';
import { Products } from '../comp-products/shared/products.model';

@Pipe({
    name: 'productFilter'
})
export class ProductFilterPipe implements PipeTransform {
    transform(products: Products[], searchTerm: string): Products[] {
        if (!products || !searchTerm) {
            return products;
        }

        return products.filter(product =>
            product.name.toLowerCase().indexOf(searchTerm.toLowerCase()) !== -1);
    }
}
