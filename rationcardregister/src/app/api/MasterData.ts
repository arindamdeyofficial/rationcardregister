import { CardCategory } from "./CardCategory";
import { Customer } from "./Customer";
import { Hof } from "./Hof";
import { Relation } from "./Relation";

export interface MasterData {
    Customers: Array<Customer>;
    Hofs: Array<Hof>;
    Relations: Array<Relation>;
    CardCategories: Array<CardCategory>;
    }