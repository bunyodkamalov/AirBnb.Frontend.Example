import {LocationEndpointsClient} from "@/infrastructures/apiClients/airBnbApiClient/brokers/LocationEndpointsClient";
import ApiClientBase from "@/infrastructures/apiClients/apiClientBase/ApiClientBase";
import {
    LocationCategoryEndpointsClient
} from "@/infrastructures/apiClients/airBnbApiClient/brokers/LocationCategoryEndpointsClient";

export class AirBnbApiClient {
    private readonly client: ApiClientBase;
    public readonly baseUrl: string;

    constructor() {
        this.baseUrl = "https://localhost:7117";

        this.client = new ApiClientBase({
            baseURL: this.baseUrl
        });

        this.locations = new LocationEndpointsClient(this.client);
        this.locationCategories = new LocationCategoryEndpointsClient(this.client);
    }

    public locations: LocationEndpointsClient;

    public locationCategories: LocationCategoryEndpointsClient;

}