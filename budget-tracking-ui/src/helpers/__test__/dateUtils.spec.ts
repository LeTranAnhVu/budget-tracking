import { describe, expect, it } from 'vitest'
import { formatDate } from '../dateUtils'

describe('dateUtils', () => {
  describe('formatDate', () => {
    it('should format ISO date string to "MMM D, YYYY" format', () => {
      const testCases = [
        {
          input: '2025-01-22T20:30:12.529276Z',
          expected: 'Jan 22, 2025',
        },
        {
          input: '2024-03-15T10:00:00.000Z',
          expected: 'Mar 15, 2024',
        },
      ]

      testCases.forEach(({ input, expected }) => {
        const result = formatDate(input)
        expect(result).toBe(expected)
      })
    })

    it('should handle invalid date strings', () => {
      expect(() => formatDate('invalid-date')).toThrow()
    })

    it('should handle empty string', () => {
      expect(() => formatDate('')).toThrow()
    })
  })
})
