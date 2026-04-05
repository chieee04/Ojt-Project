function openCreateModal() {

    document.getElementById("createModal").style.display = "flex";
}

function openTaskModal(id, title, desc) {

    document.getElementById("taskID").value = id;

    document.getElementById("modalTitle").value = title;

    document.getElementById("modalDesc").value = desc;

    document.getElementById("deleteBtn").href = "/Items/DeleteTask/" + id;

    document.getElementById("taskModal").style.display = "flex";
}

function closeModal() {

    document.getElementById("taskModal").style.display = "none";
    document.getElementById("createModal").style.display = "none";
}