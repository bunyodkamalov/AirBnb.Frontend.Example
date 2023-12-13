import type ApiClientBase from "@/infrastructures/apiClients/apiClientBase/ApiClientBase";
import type {LocationCategory} from "@/modules/locations/models/LocationCategory";

export class LocationCategoryEndpointsClient{
    private client: ApiClientBase;

    constructor(client: ApiClientBase) {
        this.client = client;
    }

    public async getAsync(){
        return await this.client.getAsync<Array<LocationCategory>>("api/locationcategory")
    }
}