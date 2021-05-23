export interface Customer {
    CustomerSerial: number;
    CustomerRowId: number;
    FamilyId: number;
    Name: string;
    Age: number;
    Address: string;
    AdharNo: string;
    RelationWithHof: string;
    RelationWithHofId: number;
    MobileNo: string;
    CardNumber: string;
    IsHof: boolean | null;
    HofId: number | null;
    HofName: string;
    GaurdianName: string;
    GaurdianRelation: string;
    GaurdianRelId: number;
    Active: boolean | null;
    CardCategory: string;
    CardCategoryId: number;
    CreatedDate: Date | null;
    InactivatedDate: Date | null;
    }