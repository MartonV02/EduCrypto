import { ImportedCryptosQuote } from "./imported-cryptos-quote.model";

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

  quotes: ImportedCryptosQuote;

  //current_price: number;
  //markte_cap: number;
  //market_cap_rank: number;
  //fully_diluted_valuation: number;
  //total_volume: number;
  //high_24h: number;
  //low_24h: number;
  //price_change_24h: number;
  //price_change_percentage_24h: number;
  //market_cap_change_24h: number;
  //market_cap_change_percentage_24h: number;
  //ath: number;
  //ath_change_percentage: number;
  //ath_date: Date;
  //atl: number;
  //atl_change_percentage: number;
  //atl_date: Date;
  //roi: null;

  /*
    "id": 1,
    "name": "Bitcoin",
    "symbol": "BTC",
    "slug": "bitcoin",
    "num_market_pairs": 9082,
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
    "circulating_supply": 18936300,
    "total_supply": 18936300,
    "platform": null,
    "cmc_rank": 1,
    "last_updated": "2022-01-21T22:03:00.000Z",
    "quote": {
        "USD": {
            "price": 36846.10365543589,
            "volume_24h": 40144941663.69582,
            "volume_change_24h": 121.9542,
            "percent_change_1h": -3.98213045,
            "percent_change_24h": -10.93482572,
            "percent_change_7d": -14.92699061,
            "percent_change_30d": -24.90529437,
            "percent_change_60d": -34.6099319,
            "percent_change_90d": -39.67761052,
            "market_cap": 697728872650.4305,
            "market_cap_dominance": 40.8999,
            "fully_diluted_market_cap": 773768176764.15,
            "last_updated": "2022-01-21T22:03:00.000Z"
        }
    }
  */
}
