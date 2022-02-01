import { ImportedCryptosQuote } from "./imported-cryptos-quote.model";
import { TestModel } from "./test.model";

export class ImportedCryptoModel
{
  id: string;
  name: string;
  symbol: string;
  slug: string;
  num_market_pairs: string;
  date_added: string;
  max_supply: number;
  circulating_supply: number;
  total_supply: number;
  last_updated: Date;
  quote: ImportedCryptosQuote;
}

/*
 {
    "status": {
        "timestamp": "2022-01-30T21:30:33.224Z",
        "error_code": 0,
        "error_message": null,
        "elapsed": 141,
        "credit_count": 5,
        "notice": null,
        "total_count": 9268
    },
    "data": [
        {
            "id": 1,
            "name": "Bitcoin",
            "symbol": "BTC",
            "slug": "bitcoin",
            "num_market_pairs": 9121,
            "date_added": "2013-04-28T00:00:00.000Z",
            "tags": [
                "mineable",
                "pow",
                "sha-256",
                "store-of-value",
                "state-channel",
                "coinbase-ventures-portfolio",
                "three-arrows-capital-portfolio",
                "polychain-capital-portfolio",
                "binance-labs-portfolio",
                "blockchain-capital-portfolio",
                "boostvc-portfolio",
                "cms-holdings-portfolio",
                "dcg-portfolio",
                "dragonfly-capital-portfolio",
                "electric-capital-portfolio",
                "fabric-ventures-portfolio",
                "framework-ventures-portfolio",
                "galaxy-digital-portfolio",
                "huobi-capital-portfolio",
                "alameda-research-portfolio",
                "a16z-portfolio",
                "1confirmation-portfolio",
                "winklevoss-capital-portfolio",
                "usv-portfolio",
                "placeholder-ventures-portfolio",
                "pantera-capital-portfolio",
                "multicoin-capital-portfolio",
                "paradigm-portfolio"
            ],
            "max_supply": 21000000,
            "circulating_supply": 18944325,
            "total_supply": 18944325,
            "platform": null,
            "cmc_rank": 1,
            "self_reported_circulating_supply": null,
            "self_reported_market_cap": null,
            "last_updated": "2022-01-30T21:29:00.000Z",
            "quote": {
                "USD": {
                    "price": 37555.81352994958,
                    "volume_24h": 14069383250.284662,
                    "volume_change_24h": -18.6587,
                    "percent_change_1h": -0.36996612,
                    "percent_change_24h": -2.59077473,
                    "percent_change_7d": 6.25130557,
                    "percent_change_30d": -18.5209048,
                    "percent_change_60d": -33.65132664,
                    "percent_change_90d": -38.15011926,
                    "market_cap": 711469537150.762,
                    "market_cap_dominance": 41.931,
                    "fully_diluted_market_cap": 788672084128.94,
                    "last_updated": "2022-01-30T21:29:00.000Z"
                }
            }
        }
     }
 }
*/
