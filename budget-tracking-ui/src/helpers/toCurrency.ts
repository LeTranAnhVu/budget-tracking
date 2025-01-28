import { CURRENCY } from '@/constants'

export default function toCurrency(amount: number, withSymbol: boolean = true): string {
  const prefix = withSymbol ? `${CURRENCY}` : ''
  return `${prefix}${amount.toFixed(2)}`
}
