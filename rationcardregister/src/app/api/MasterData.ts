import { CardCategory } from "./CardCategory";
import { CategoryWise } from "./CategoryWise";
import { Customer } from "./Customer";
import { Hof } from "./Hof";
import { Relation } from "./Relation";

export class MasterData {
    Customers: Array<Customer>;
    Hofs: Array<Hof>;
    Relations: Array<Relation>;
    CardCategories: Array<CardCategory>;
    CategoryWiseCount: Array<CategoryWise>;
    }