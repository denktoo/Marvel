async function fetchEntity() {
    const entityPath = document.getElementById('entityPath').value;
    if (!entityPath) {
        alert('Please enter an entity path.');
        return;
    }

    try {
        const response = await fetch(`https://localhost:7164/api/${entityPath}`);
        if (!response.ok) {
            throw new Error('Entity not found');
        }
        const entity = await response.json();

        // Display full entity details as formatted JSON
        document.getElementById('entityDetails').innerHTML = `<pre>${JSON.stringify(entity, null, 2)}</pre>`;

    } catch (error) {
        document.getElementById('entityDetails').innerHTML = `<p style="color:red;">${error.message}</p>`;
    }
}