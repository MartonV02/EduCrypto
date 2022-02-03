import { ImportedCryptosQuote } from "./imported-cryptos-quote.model";

export class ImportedCryptoModel
{
  id: string;
  name: string;
  symbol: string;
  date_added: string;
  max_supply: number;
  circulating_supply: number;
  last_updated: Date;
  quote: ImportedCryptosQuote;
}
