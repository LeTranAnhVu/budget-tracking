/**
 * Formats an ISO date string to a more readable format (e.g., "Jan 22, 2025")
 * @param dateString - ISO date string (e.g., "2025-01-22T20:30:12.529276Z")
 * @returns Formatted date string (e.g., "Jan 22, 2025")
 * @throws Error if the date string is invalid or empty
 */
export function formatDate(dateString: string): string {
  if (!dateString) {
    throw new Error('Date string cannot be empty')
  }

  const date = new Date(dateString)

  // Check if date is invalid
  if (Number.isNaN(date.getTime())) {
    throw new TypeError('Invalid date string provided')
  }

  return date.toLocaleDateString('en-US', {
    month: 'short',
    day: 'numeric',
    year: 'numeric',
  })
}
