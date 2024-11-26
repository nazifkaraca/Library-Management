document.querySelectorAll('.table-hover tbody tr').forEach(row => {
	row.addEventListener('mouseover', () => {
		row.style.backgroundColor = '#f0f8ff'; // Highlight color
	});
	row.addEventListener('mouseout', () => {
		row.style.backgroundColor = ''; // Reset color
	});
});