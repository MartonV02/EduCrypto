//import { ImportedCryptosQuote } from "./imported-cryptos-quote.model";

export class ImportedCryptoModel
{
  id: string;
  name: string;
  symbol: string;
  date_added: string;
  max_supply: number;
  circulating_supply: number;
  last_updated: Date;
  percent_Change24h: number;
  percent_Change30d: number;
  percent_Change90d: number;
  actual_USD_Price: number;
  //quote: ImportedCryptosQuote;
}
